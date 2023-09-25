import { useState } from "react"
import { NavLink } from "react-router-dom"

//Mui Components
import Avatar from "@mui/material/Avatar"
import Button from "@mui/material/Button"
import TextField from "@mui/material/TextField"
import Box from "@mui/material/Box"
import Grid from "@mui/material/Grid"
import LockOutlinedIcon from "@mui/icons-material/LockOutlined"
import Typography from "@mui/material/Typography"

import useUserStore from "../../stores/userStore"
import { Navigate } from "react-router-dom"

const Login = () => {
	const [email, setEmail] = useState()
	const [password, setPassword] = useState()
	const asyncGetUserById = useUserStore(state => state.asyncGetUserById)
	const error = useUserStore(state => state.error)
	const asyncLogin = useUserStore(state => state.asyncLogin)
	const isAuth = useUserStore(state => state.isAuth)
	const asyncGetOrders = useUserStore(state => state.asyncGetOrders)

	const onChangeEmail = e => {
		setEmail(e.target.value)
	}

	const onChangePassword = e => {
		setPassword(e.target.value)
	}

	const login = async () => {
		await asyncLogin({ email: email, password: password })
		await asyncGetUserById()
		await asyncGetOrders()
	}

	return (
		<Grid component="main" display="flex" justifyContent="center" sx={{ height: "100vh" }}>
			{isAuth ? (
				<Navigate to="/" />
			) : (
				<Grid>
					<Box
						display="flex"
						flexDirection="column"
						alignItems="center"
						sx={{
							mx: 4,
							my: 8
						}}
					>
						<Avatar sx={{ m: 1, bgcolor: "dark" }}>
							<LockOutlinedIcon />
						</Avatar>
						<Typography sx={{ fontFamily: "Rajdhani" }} component="h1" variant="h5">
							Login
						</Typography>
						<Box component="form" display={"flex"} flexDirection={"column"} noValidate sx={{ mt: 1 }}>
							<TextField
								onChange={onChangeEmail}
								margin="normal"
								required
								fullWidth
								label="Email Address"
								variant="standard"
								color="dark"
							/>
							<TextField
								onChange={onChangePassword}
								margin="normal"
								required
								fullWidth
								label="Password"
								type="password"
								variant="standard"
								color="dark"
							/>

							<Typography sx={{ m: "8" }} variant="caption" color="error">
								{error}
							</Typography>

							<Button
								sx={{ fontFamily: "Rajdhani" }}
								fullWidth
								variant="outlined"
								color="dark"
								component={NavLink}
								onClick={login}
							>
								Login
							</Button>
							<Typography
								sx={{ textDecoration: 0, color: "gray", marginTop: 4 }}
								component={NavLink}
								to="/register"
								color="dark"
							>
								Нет аккаунта? Зарегистрироваться
							</Typography>
						</Box>
					</Box>
				</Grid>
			)}
		</Grid>
	)
}

export default Login
