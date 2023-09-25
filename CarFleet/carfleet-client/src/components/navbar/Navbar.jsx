import Grid from "@mui/material/Unstable_Grid2"
import { AppBar, Typography, Container, Box } from "@mui/material"

import { NavLink } from "react-router-dom"

import Logo from "../logo/Logo"
import NavbarLink from "../navbar_link/NavbarLink"
import routes from "../../routes"

const getNavbarLink = () => {
	var navbarLinks = routes.map(route => {
		return (
			<Grid key={route.name} marginX={1} display="flex" justifyContent="center" alignItems="center">
				<NavbarLink value={route.name} route={route.route} />
			</Grid>
		)
	})
	return navbarLinks
}

const Navbar = () => {
	return (
		<AppBar position="static">
			<Container maxWidth="lg">
				<Box>
					<Grid container>
						<Grid xs={3}>
							<Typography component={NavLink} to="/">
								<Logo />
							</Typography>
						</Grid>
						<Grid xs={9} display="flex" alignItems="center" justifyContent="flex-end">
							{getNavbarLink()}
						</Grid>
					</Grid>
				</Box>
			</Container>
		</AppBar>
	)
}

export default Navbar
