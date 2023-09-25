import { Box, Card, Button, Typography } from "@mui/material"
import Grid from "@mui/material/Unstable_Grid2/Grid2"
import useVehicleStore from "../../stores/vehicleStore"
import { useEffect, useState } from "react"

const OrderCard = ({ photo, pickupDate, pickupPlace, dropoffDate, dropoffPlace, vehicleId, id, handleOrder }) => {
	const allVehicles = useVehicleStore(state => state.vehicles)
	const [vehicle, setVehicle] = useState({})
	const [loading, setLoading] = useState(true)

	const findVehicle = () => {
		allVehicles.forEach(v => {
			if (v.id === vehicleId) {
				setVehicle(v)
				setLoading(false)
			}
		})
	}

	useEffect(() => {
		findVehicle()
	})

	return (
		<>
			{loading ? (
				<p>Loading</p>
			) : (
				<Grid
					xs={3}
					padding={0}
					display={"flex"}
					flexDirection={"column"}
					justifyContent={"start"}
					marginX={3}
					marginBottom={3}
					component={Card}
					borderRadius={2}
				>
					<Grid
						minHeight={"150px"}
						width={"100%"}
						sx={{
							backgroundImage: `url(${photo})`,
							backgroundPosition: "center",
							backgroundSize: "100%",
							backgroundRepeat: "no-repeat"
						}}
					></Grid>
					<Grid height={"100%"} display={"flex"} flexDirection={"column"} justifyContent={"space-between"}>
						<Grid margin={3} container display={"flex"} flexDirection={"column"}>
							<Grid container display={"flex"} justifyContent={"space-between"}>
								<Box>
									<Typography variant="h6" sx={{ fontFamily: "Rajdhani" }}>
										{vehicle.brand} {vehicle.model}
									</Typography>
								</Box>
								<Box>
									<Typography variant="overline">{vehicle.price}$</Typography>
								</Box>
							</Grid>
							<Grid padding={0}>
								<Box>
									<Typography variant="overline" noWrap>
										Pickup Date: {new Date(pickupDate).toLocaleString()}
									</Typography>
								</Box>
								<Box>
									<Typography variant="overline" noWrap>
										Dropoff Date: {new Date(dropoffDate).toLocaleString()}
									</Typography>
								</Box>
								<Box>
									<Typography variant="overline" noWrap>
										Pickup Place: {pickupPlace}
									</Typography>
								</Box>
								<Box>
									<Typography variant="overline" noWrap>
										Dropoff Place: {dropoffPlace}
									</Typography>
								</Box>
							</Grid>
						</Grid>
						<Grid margin={2} container display={"flex"} justifyContent={"space-between"}>
							<Grid padding={0}>
								<Button
									id={id}
									onClick={handleOrder}
									variant="outlined"
									fullWidth
									color="dark"
									size="medium"
								>
									Close
								</Button>
							</Grid>
						</Grid>
					</Grid>
				</Grid>
			)}
		</>
	)
}

export default OrderCard
