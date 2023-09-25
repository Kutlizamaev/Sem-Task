import { useState } from "react"
import useVehicleStore from "../../stores/vehicleStore"

const UploadPage = () => {
	const addVehicle = useVehicleStore(state => state.addVehicle)
	const [image, setImageUrl] = useState()
	const [model, setModel] = useState("")
	const [brand, setBrand] = useState("")
	const [categoryid, setCategory] = useState("")
	const [horsePower, setHorsePower] = useState("")
	const [description, setDescription] = useState("")
	const [price, setPrice] = useState("")
	const [number, setNumber] = useState("")
	const [mileage, setMileage] = useState("")

	const fileBrowseHandler = event => {
		setImageUrl(event.target.files[0])
	}

	const handleBrand = e => {
		setBrand(e.target.value)
	}
	const handleModel = e => {
		setModel(e.target.value)
	}
	const handleCategory = e => {
		setCategory(e.target.value)
	}
	const handleHorsePower = e => {
		setHorsePower(e.target.value)
	}
	const handleDescription = e => {
		setDescription(e.target.value)
	}
	const handlePrice = e => {
		setPrice(e.target.value)
	}
	const handleNumber = e => {
		setNumber(e.target.value)
	}
	const handleMileage = e => {
		setMileage(e.target.value)
	}

	const addingVehicle = async () => {
		await addVehicle(image, brand, model, categoryid, horsePower, description, price, number, mileage)
	}

	return (
		<div>
			<input type="text" onChange={handleBrand} value="Brand" />
			<input type="text" onChange={handleModel} value="Model" />
			<input type="text" onChange={handleCategory} value="0" />
			<input type="text" onChange={handleDescription} value="Description" />
			<input type="text" onChange={handlePrice} value="100" />
			<input type="text" onChange={handleHorsePower} value="250" />
			<input type="text" onChange={handleNumber} value="5" />
			<input type="text" onChange={handleMileage} value="1000" />
			<input type="file" onChange={fileBrowseHandler} />
			<button onClick={addingVehicle}>Upload</button>
		</div>
	)
}

export default UploadPage
