import { initializeApp } from "firebase/app"
import { getStorage } from "firebase/storage"

const firebaseConfig = {
	apiKey: "AIzaSyD92-bcW_9JblRcW7F-RD1AcwqmIIuk_WY",
	authDomain: "carfleet-777.firebaseapp.com",
	projectId: "carfleet-777",
	storageBucket: "carfleet-777.appspot.com",
	messagingSenderId: "201166987338",
	appId: "1:201166987338:web:7a2a149c4922912bf086b3",
	measurementId: "G-FWXW4FN2TL"
}

const app = initializeApp(firebaseConfig)
export const storage = getStorage(app)
