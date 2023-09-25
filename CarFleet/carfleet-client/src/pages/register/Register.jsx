import { useState } from "react"
import { NavLink, Navigate } from "react-router-dom"

import Avatar from "@mui/material/Avatar"
import Button from "@mui/material/Button"
import TextField from "@mui/material/TextField"
import Box from "@mui/material/Box"
import Grid from "@mui/material/Grid"
import LockOutlinedIcon from "@mui/icons-material/LockOutlined"
import Typography from "@mui/material/Typography"

import useUserStore from "../../stores/userStore"

const Register = () => {
	const [fullname, setFullname] = useState()
	const [username, setUsername] = useState()
	const [email, setEmail] = useState()
	const [password, setPassword] = useState()
	const [address, setAddress] = useState()
	const [birthDate, setBirthDate] = useState()
	const [isRegister, setIsRegister] = useState(false)
	const asyncRegister = useUserStore(state => state.asyncRegister)

	const onChangeFullname = e => {
		setFullname(e.target.value)
	}

	const onChangeUsername = e => {
		setUsername(e.target.value)
	}

	const onChangeEmail = e => {
		setEmail(e.target.value)
	}

	const onChangePassword = e => {
		setPassword(e.target.value)
	}

	const onChangeAddress = e => {
		setAddress(e.target.value)
	}

	const onChangeBirthDate = e => {
		setBirthDate(e)
	}

	const register = async () => {
		await asyncRegister(fullname, username, email, password, address, birthDate)
		setIsRegister(true)
	}

	if (isRegister) {
		return <Navigate to="/login" />
	}

	return (
		<Grid display="flex" justifyContent="center" sx={{ height: "100vh" }}>
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
						Register
					</Typography>
					<Box component="form" display={"flex"} flexDirection={"column"} validate sx={{ mt: 1 }}>
						<TextField
							onChange={onChangeFullname}
							margin="normal"
							required
							fullWidth
							label="Fullname"
							variant="standard"
							color="dark"
						/>
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
							onChange={onChangeUsername}
							margin="normal"
							required
							fullWidth
							label="Username"
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
						<TextField
							onChange={onChangeAddress}
							margin="normal"
							required
							fullWidth
							label="Address"
							variant="standard"
							color="dark"
						/>
						<TextField
							onChange={onChangeBirthDate}
							margin="normal"
							required
							fullWidth
							type="date"
							label="BirthDate"
							variant="standard"
							color="dark"
							focused
						/>

						<Typography sx={{ m: "8" }} variant="caption" color="error"></Typography>

						<Button
							sx={{ fontFamily: "Rajdhani" }}
							fullWidth
							variant="outlined"
							color="dark"
							component={NavLink}
							onClick={register}
						>
							Register
						</Button>
						<Typography
							sx={{ textDecoration: 0, color: "gray", marginTop: 4 }}
							component={NavLink}
							to="/login"
							color="dark"
						>
							Есть аккаунт? Авторизоваться
						</Typography>
					</Box>
				</Box>
			</Grid>
		</Grid>
	)
}

export default Register
