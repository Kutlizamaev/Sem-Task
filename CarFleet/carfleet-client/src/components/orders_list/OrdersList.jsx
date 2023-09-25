import OrderCard from "../order_card/OrderCard"
import useUserStore from "../../stores/userStore"
import Grid from "@mui/material/Unstable_Grid2/Grid2"

const OrdersList = ({ orders }) => {
	const closeOrder = useUserStore(state => state.closeOrder)

	const handleOrder = async button => {
		await closeOrder(button.target.id)
	}

	const renderOrders = orders => {
		return orders.map((order, index) => (
			<OrderCard
				key={index}
				id={order.id}
				photo={order.photo}
				pickupDate={order.pickupDate}
				pickupPlace={order.pickupPlace}
				dropoffDate={order.dropoffDate}
				dropoffPlace={order.dropoffPlace}
				vehicleId={order.vehicleId}
				handleOrder={handleOrder}
			/>
		))
	}

	return (
		<Grid marginTop={4} display={"flex"} justifyContent={"center"} container>
			{renderOrders(orders)}
		</Grid>
	)
}

export default OrdersList
