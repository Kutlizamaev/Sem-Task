import { Button } from "@mui/material"
import { NavLink } from "react-router-dom"
import { theme } from "../../assets/theme/theme"

const NavbarLink = props => {
	return (
		<Button
			sx={{ fontFamily: "Rajdhani", color: theme.dark }}
			variant="outlined"
			color="dark"
			component={NavLink}
			to={props.route}
		>
			{props.value}
		</Button>
	)
}

export default NavbarLink
