import { Container } from "@mui/material"
import Grid from "@mui/material/Unstable_Grid2/Grid2"
import useVehicleStore from "../../stores/vehicleStore"
import AutoCard from "../../components/inventory_card/AutoCard"
import { Navigate } from "react-router-dom"
import { useState } from "react"

const Inventory = () => {
	const vehicles = useVehicleStore(state => state.vehicles)
	const loading = useVehicleStore(state => state.loading)
	var [idCard, setIdCard] = useState()

	const toBooking = button => {
		setIdCard(button.target.id)
	}

	const renderVehiclesCard = (vehicles, toBooking) => {
		return vehicles.map(vehicle => (
			<AutoCard
				key={vehicle.id}
				id={vehicle.id}
				brand={vehicle.brand}
				model={vehicle.model}
				photo={vehicle.photo}
				category={vehicle.category}
				description={vehicle.description}
				price={vehicle.price}
				functionForNavigate={toBooking}
			/>
		))
	}

	if (idCard) {
		return <Navigate to={"/booking"} state={idCard} />
	}

	return (
		<Container>
			{!loading ? (
				<Grid marginTop={4} display={"flex"} justifyContent={"center"} container>
					{renderVehiclesCard(vehicles, toBooking)}
				</Grid>
			) : (
				<p>Загрузка</p>
			)}
		</Container>
	)
}

export default Inventory
