import { Box, Card, Button, Typography } from "@mui/material"
import Grid from "@mui/material/Unstable_Grid2/Grid2"

const AutoCard = props => {
	return (
		<Grid
			xs={3}
			padding={0}
			display={"flex"}
			flexDirection={"column"}
			justifyContent={"start"}
			marginX={3}
			marginBottom={3}
			component={Card}
			borderRadius={2}
		>
			<Grid
				minHeight={"150px"}
				width={"100%"}
				sx={{
					backgroundImage: `url(${props.photo})`,
					backgroundPosition: "center",
					backgroundSize: "100%",
					backgroundRepeat: "no-repeat"
				}}
			></Grid>
			<Grid height={"100%"} display={"flex"} flexDirection={"column"} justifyContent={"space-between"}>
				<Grid margin={3} container display={"flex"} flexDirection={"column"}>
					<Grid container display={"flex"} justifyContent={"space-between"}>
						<Box>
							<Typography variant="h6" sx={{ fontFamily: "Rajdhani" }}>
								{props.brand} {props.model}
							</Typography>
							<Typography variant="subtitle1">{props.category}</Typography>
						</Box>
						<Box>
							<Typography variant="overline">{props.price}$</Typography>
						</Box>
					</Grid>
					<Grid padding={0}>
						<Typography variant="caption">{props.description}</Typography>
					</Grid>
				</Grid>
				<Grid margin={2} container display={"flex"} justifyContent={"space-between"}>
					<Grid padding={0}>
						<Button variant="outlined" color="dark" size="medium">
							View
						</Button>
					</Grid>
					<Grid padding={0}>
						<Button
							variant="outlined"
							onClick={props.functionForNavigate}
							id={props.id}
							fullWidth
							color="dark"
							size="medium"
						>
							Book
						</Button>
					</Grid>
				</Grid>
			</Grid>
		</Grid>
	)
}

export default AutoCard
