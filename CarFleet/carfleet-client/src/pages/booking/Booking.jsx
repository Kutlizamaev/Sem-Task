import { Box, Card, Typography, TextField, Button } from "@mui/material/"
import { DateTimePicker } from "@mui/x-date-pickers"
import { Container } from "@mui/material"
import Grid from "@mui/material/Unstable_Grid2/Grid2"
import useVehicleStore from "../../stores/vehicleStore"
import { useLocation } from "react-router-dom"
import { useState } from "react"
import useUserStore from "../../stores/userStore"

const Booking = () => {
	const [pickupDate, setPickupDate] = useState()
	const [pickupPlace, setPickupPlace] = useState()
	const [dropoffDate, setDropoffDate] = useState()
	const [dropoffPlace, setDropoffPlace] = useState()
	const booking = useUserStore(state => state.bookVehicle)
	const id = useLocation().state
	const getVehicleById = useVehicleStore(state => state.getVehicleById)

	const vehicle = getVehicleById(id)

	const handlePickupDate = e => {
		var date = new Date(e["$d"]).toISOString()
		setPickupDate(date)
	}

	const handlePickupPlace = e => {
		setPickupPlace(e.target.value)
	}

	const handleDropoffDate = e => {
		var date = new Date(e["$d"]).toISOString()
		setDropoffDate(date)
	}

	const handleDropoffPlace = e => {
		setDropoffPlace(e.target.value)
	}

	const book = async () => {
		await booking(id, pickupDate, pickupPlace, dropoffDate, dropoffPlace)
	}

	return (
		<Container maxWidth="lg">
			<Grid component={Card} elevation={3} marginTop={4}>
				<Grid margin={4}>
					<Box display={"flex"} justifyContent={"center"} alignItems={"center"}>
						<Typography sx={{ fontFamily: "Rajdhani" }} variant="h4">
							Booking
						</Typography>
					</Box>
				</Grid>
				<Grid margin={4} display={"flex"} justifyContent={"space-around"}>
					<Grid component={Card} elevation={2} xs={6}>
						<Grid>
							<Grid display={"flex"} justifyContent={"space-evenly"}>
								<Box margin={2}>
									<DateTimePicker onChange={handlePickupDate} label="Pickup date" />
								</Box>
								<Box margin={2}>
									<TextField label="Pickup place" onChange={handlePickupPlace} color="dark" />
								</Box>
							</Grid>
							<Grid display={"flex"} justifyContent={"space-evenly"}>
								<Box margin={2}>
									<DateTimePicker onChange={handleDropoffDate} label="Dropoff date" />
								</Box>
								<Box margin={2}>
									<TextField label="Dropoff place" onChange={handleDropoffPlace} color="dark" />
								</Box>
							</Grid>
						</Grid>
						<Grid display={"flex"} justifyContent={"start"} alignItems={"center"}>
							<Box margin={2}>
								<Button onClick={book} color="dark" size="large" variant="outlined">
									Booking
								</Button>
							</Box>
						</Grid>
					</Grid>
					<Grid component={Card} elevation={2} xs={5}>
						<Grid display={"flex"}>
							<Box margin={2}>
								<Grid>
									<Box>
										<Typography variant="overline" noWrap>
											Brand: {vehicle.brand}
										</Typography>
									</Box>
									<Box>
										<Typography variant="overline" noWrap>
											Model: {vehicle.model}
										</Typography>
									</Box>

									<Box>
										<Typography variant="overline" noWrap>
											Price: {vehicle.price}$/day
										</Typography>
									</Box>
									<Box>
										<Typography variant="overline" noWrap>
											Horsepower: {vehicle.horsepower}hp
										</Typography>
									</Box>
									<Box>
										<Typography variant="overline" noWrap>
											Number of seats: {vehicle.numberOfSeats}
										</Typography>
									</Box>
									<Box>
										<Typography variant="overline" noWrap>
											Mileage: {vehicle.mileage}km
										</Typography>
									</Box>
								</Grid>
							</Box>
							<Box margin={2}>
								<img
									src={vehicle.photo}
									alt="auto"
									width="300px"
									style={{ borderRadius: "12px", boxShadow: "0px 1px 7px 0px rgba(0,0,0,0.7)" }}
								/>
							</Box>
						</Grid>
					</Grid>
				</Grid>
			</Grid>
		</Container>
	)
}

export default Booking
