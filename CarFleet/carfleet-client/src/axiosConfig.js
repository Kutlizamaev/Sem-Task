import axios from "axios"

const baseURL = "https://localhost:5001"

const baseAPI = axios.create({
	baseURL: baseURL
})

const getConfig = (token, params) => {
	if (token) {
		return {
			baseURL: baseURL,
			headers: {
				Authorization: "Bearer " + token
			},
			params: params
		}
	} else {
		return {
			baseURL: baseURL,
			params: params
		}
	}
}

const API = {
	GET: (path, token, params) => baseAPI.get(path, getConfig(token, params)),
	POST: (path, data, token) => baseAPI.post(path, data, getConfig(token)),
	DELETE: (path, params, token) => baseAPI.delete(path, getConfig(token, params))
}

export default API
