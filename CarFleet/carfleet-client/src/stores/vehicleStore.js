import { create } from "zustand"
import { storage } from "../firebase"
import { ref, getDownloadURL } from "firebase/storage"
import API from "../axiosConfig"
import { persist } from "zustand/middleware"

const useVehicleStore = create(
	persist(
		(set, get) => ({
			vehicles: [],
			error: null,
			loading: true,

			getVehicles: async () => {
				return await API.GET("/api/vehicle/get").then(response => {
					response.data.forEach(v => {
						const imageRef = ref(storage, `${v.id}.jpg`)

						getDownloadURL(imageRef).then(url => {
							Object.defineProperty(v, "photo", { value: url })
						})
					})

					set({ loading: false, vehicles: response.data })
				})
			},

			getVehicleById: id => {
				var currentVehicle = {}
				const vehiclesArray = get().vehicles

				vehiclesArray.forEach(vehicle => {
					if (vehicle.id === id) {
						currentVehicle = vehicle
					}
				})

				return currentVehicle
			},

			addVehicle: async (image, brand, model, categoryid, horsePower, description, price, number, mileage) => {
				const jwt = JSON.parse(localStorage.getItem("JWT"))

				const formData = new FormData()
				formData.append("categoryId", categoryid)
				formData.append("brand", brand)
				formData.append("model", model)
				formData.append("description", description)
				formData.append("pathFile", image)
				formData.append("price", parseInt(price))
				formData.append("horsePower", parseInt(horsePower))
				formData.append("numberOfSeats", parseInt(number))
				formData.append("mileage", parseInt(mileage))

				console.log(get().vehicles)

				await API.POST("/api/vehicle/add", formData, jwt.token)
			}
		}),
		{
			name: "vehicle-state"
		}
	)
)

export default useVehicleStore
