import { create } from "zustand"
import { persist } from "zustand/middleware"
import API from "../axiosConfig"
import jwtDecode from "jwt-decode"
import { storage } from "../firebase"
import { ref, getDownloadURL } from "firebase/storage"

const useUserStore = create(
	persist(
		(set, get) => ({
			currentUser: {},
			orders: [],
			loading: false,
			error: null,
			isAuth: false,

			asyncLogin: async ({ email, password }) => {
				set({ loading: true })

				const formData = new FormData()
				formData.append("email", email)
				formData.append("password", password)

				await API.POST("/api/account/login", formData).then(response => {
					if (response.data.token) {
						localStorage.setItem("JWT", JSON.stringify(response.data))
						set({ isAuth: true })
					}
				})

				set({ loading: false })
			},

			asyncRegister: async (fullname, username, email, password, address, birthDate) => {
				const formData = new FormData()
				var date = new Date(birthDate.target.valueAsDate)
				formData.append("fullname", fullname)
				formData.append("username", username)
				formData.append("email", email)
				formData.append("password", password)
				formData.append("address", address)
				formData.append("birthDate", date.toISOString())

				set({ loading: true })

				return await API.POST("/api/account/register", formData).then(response => {
					set({ loading: false })
				})
			},

			asyncGetUserById: async () => {
				const jwt = JSON.parse(localStorage.getItem("JWT"))
				const user = jwtDecode(jwt.token)
				return await API.GET("/api/account/get", jwt.token, { id: user.id }).then(response => {
					set({ currentUser: response.data })
				})
			},

			asyncGetOrders: async () => {
				set({ loading: true })
				const jwt = JSON.parse(localStorage.getItem("JWT"))
				const user = jwtDecode(jwt.token)
				const orders = []

				await API.GET("/api/account/orders", jwt.token, { id: user.id }).then(response => {
					response.data.forEach(v => {
						const imageRef = ref(storage, `${v.vehicleId}.jpg`)

						getDownloadURL(imageRef).then(url => {
							orders.push({
								id: v.id,
								pickupDate: v.pickupDate,
								pickupPlace: v.pickupPlace,
								dropoffDate: v.dropoffDate,
								dropoffPlace: v.dropoffPlace,
								userId: v.userId,
								vehicleId: v.vehicleId,
								photo: url
							})
						})
					})
				})

				set({ orders: orders, loading: false })
			},

			bookVehicle: async (vehicleId, pickupDate, pickupPlace, dropoffDate, dropoffPlace) => {
				var jwt = JSON.parse(localStorage.getItem("JWT"))
				var user = jwtDecode(localStorage.getItem("JWT"))
				var orders = get().orders

				var formData = new FormData()
				formData.append("userId", user.id)
				formData.append("vehicleId", vehicleId)
				formData.append("pickupDate", pickupDate)
				formData.append("pickupPlace", pickupPlace)
				formData.append("dropoffDate", dropoffDate)
				formData.append("dropoffPlace", dropoffPlace)

				await API.POST("/api/booking/book", formData, jwt.token).then(response => {
					if (response.status === 200) {
						const imageRef = ref(storage, `${vehicleId}.jpg`)

						getDownloadURL(imageRef).then(url => {
							orders.push({
								id: response.data,
								pickupDate: pickupDate,
								pickupPlace: pickupPlace,
								dropoffDate: dropoffDate,
								dropoffPlace: dropoffPlace,
								userId: user.id,
								vehicleId: vehicleId,
								photo: url
							})
						})
					}
				})

				set({ orders: orders })
			},

			closeOrder: async id => {
				var jwt = JSON.parse(localStorage.getItem("JWT"))
				const orders = get().orders
				var counter = 0

				await API.GET("/api/booking/close", jwt.token, { id: id }).then(response => {
					console.log(response.status)
				})

				orders.forEach(o => {
					if (id === o.id) {
						orders.splice(counter, 1)
					}
					counter += 1
				})

				set({ orders: orders })
			},

			logout: () => {
				set({ isAuth: false, currentUser: {} })
				localStorage.removeItem("JWT")
				localStorage.removeItem("user-state")
			}
		}),
		{
			name: "user-state"
		}
	)
)

export default useUserStore
