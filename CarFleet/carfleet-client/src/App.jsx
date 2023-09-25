import { Route, Routes } from "react-router-dom"
import Login from "./pages/login/Login"
import Register from "./pages/register/Register"
import Home from "./pages/home/Home"
import Profile from "./pages/profile/Profile"
import Navbar from "./components/navbar/Navbar"
import { ThemeProvider } from "@mui/material"
import { theme } from "./assets/theme/theme"
import Booking from "./pages/booking/Booking"
import Inventory from "./pages/inventory/Inventory"
import Contact from "./pages/contact/Contact"
import About from "./pages/about/About"
import { LocalizationProvider } from "@mui/x-date-pickers"
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs"
import useVehicleStore from "./stores/vehicleStore"
import UploadPage from "./pages/upload/UploadPage"

const App = () => {
	const getVehicles = useVehicleStore(state => state.getVehicles)
	getVehicles()

	return (
		<>
			<ThemeProvider theme={theme}>
				<Navbar />
				<LocalizationProvider dateAdapter={AdapterDayjs}>
					<Routes>
						<Route path="/" element={<Home />} />
						<Route path="/booking" element={<Booking />} />
						<Route path="/inventory" element={<Inventory />} />
						<Route path="/contact" element={<Contact />} />
						<Route path="/about" element={<About />} />
						<Route path="/profile" element={<Profile />} />

						<Route path="/login" element={<Login />} />
						<Route path="/register" element={<Register />} />
						<Route path="/addvehicle" element={<UploadPage />} />
					</Routes>
				</LocalizationProvider>
			</ThemeProvider>
		</>
	)
}

export default App
