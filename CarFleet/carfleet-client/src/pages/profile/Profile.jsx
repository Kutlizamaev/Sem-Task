import { Box, Button, Card, Typography } from "@mui/material/"
import { Container } from "@mui/material"
import Grid from "@mui/material/Unstable_Grid2/Grid2"
import useUserStore from "../../stores/userStore"
import { Navigate } from "react-router-dom"
import OrdersList from "../../components/orders_list/OrdersList"

const Profile = () => {
	const user = useUserStore(state => state.currentUser)
	const logout = useUserStore(state => state.logout)
	const isAuth = useUserStore(state => state.isAuth)
	const orders = useUserStore(state => state.orders)

	return (
		<Container maxWidth="lg">
			{isAuth ? (
				<>
					<Grid component={Card} marginTop={4}>
						<Box sx={{ display: "flex", justifyContent: "space-between", alignItems: "center" }} margin={4}>
							<Typography variant="h4" sx={{ fontFamily: "Rajdhani" }}>
								{user.userName}
							</Typography>
							<Box display={"flex"} justifyContent={"space-between"}>
								<Button color="dark" variant="outlined">
									Options
								</Button>
								<Button onClick={logout} color="dark" variant="outlined">
									Logout
								</Button>
							</Box>
						</Box>
						<hr />
						<Box display={"flex"} justifyContent={"space-between"}>
							<Box margin={2}>
								<Typography variant="overline" display={"block"}>
									Full Name: {user.fullName}
								</Typography>
								<Typography variant="overline" display={"block"}>
									Email: {user.email}
								</Typography>
								<Typography variant="overline" display={"block"}>
									Address: {user.address}
								</Typography>
								<Typography variant="overline" display={"block"}>
									BirthDate: {new Date(user.birthDate).toLocaleDateString().substring(0, 10)}
								</Typography>
							</Box>
						</Box>
					</Grid>
					<Box textAlign={"center"} marginTop={4}>
						<Typography display={"block"} variant="h4" sx={{ fontFamily: "Rajdhani" }}>
							Your orders
						</Typography>
					</Box>

					<OrdersList orders={orders} />
				</>
			) : (
				<Navigate to="/login" />
			)}
		</Container>
	)
}

export default Profile
