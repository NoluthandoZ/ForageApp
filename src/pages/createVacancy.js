import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import Paper from "@mui/material/Paper";
import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import Typography from "@mui/material/Typography";
import { Container } from "@mui/material";
import { useNavigate } from 'react-router-dom';
import { useState } from "react";

export default function CreateVacancy() {
    const navigate = useNavigate();
    const [signResponse, setSignResponse] = useState();

    const handleSubmit = (event) => {
        event.preventDefault();
        const data = new FormData(event.currentTarget);

        let infor = {
            closingDate: "2023-06-15T09:02:44.041Z",
            description: data.get("description"),
            companyName: data.get("companyName"),
            requirements: data.get("requirements"),
            vacany_type: data.get("vacancyType")

        }


        fetch('https://localhost:7031/api/vacancies/Vacancy', {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(infor)
        }).then(response => setSignResponse(response))

        navigate("/vacancy");   
      
       
    };

    return (
        <Container component="main" maxWidth="lg">
            <Box
                sx={{
                    marginTop: 8,
                }}
            >
                <Grid container>
                    <CssBaseline />
                    <Grid
                        item
                        xs={false}
                        sm={4}
                        md={7}
                        sx={{
                            backgroundImage: "url(https://source.unsplash.com/random)",
                            backgroundRepeat: "no-repeat",
                            backgroundColor: (t) =>
                                t.palette.mode === "light"
                                    ? t.palette.grey[50]
                                    : t.palette.grey[900],
                            backgroundSize: "cover",
                            backgroundPosition: "center",
                        }}
                    />
                    <Grid
                        item
                        xs={12}
                        sm={8}
                        md={5}
                        component={Paper}
                        elevation={6}
                        square
                    >
                        <Box
                            sx={{
                                my: 8,
                                mx: 4,
                                display: "flex",
                                flexDirection: "column",
                                alignItems: "center",
                            }}
                        >
                            <Typography component="h1" variant="h5">
                               Create Vacancy
                            </Typography>
                            <Box
                                component="form"
                                noValidate
                                onSubmit={handleSubmit}
                                sx={{ mt: 1 }}
                            >
                                <TextField
                                    margin="normal"
                                    required
                                    fullWidth
                                    name="companyName"
                                    label="Company Name"
                                    type="text"
                                    id="companyName"
                                />
                                <TextField
                                    margin="normal"
                                    required
                                    fullWidth
                                    name="requirements"
                                    label="Requirements"
                                    type="text"
                                    id="requirements"
                                />
                                <TextField
                                    margin="normal"
                                    required
                                    fullWidth
                                    name="closingDate"
                                    label="Closing Date"
                                    type="text"
                                    id="closingDate"
                                />
                                <TextField
                                    margin="normal"
                                    required
                                    fullWidth
                                    name="vacancyType"
                                    label="Vacancy Type"
                                    type="text"
                                    id="vacancyType"
                                />
                                <TextField
                                    margin="normal"
                                    required
                                    fullWidth
                                    name="description"
                                    label="Description"
                                    type="text"
                                    id="description"
                                />
                                <Button
                                    type="submit"
                                    fullWidth
                                    variant="contained"
                                    sx={{ mt: 3, mb: 2 }}
                                >
                                    SAVE
                                </Button>
                            </Box>
                        </Box>
                    </Grid>
                </Grid>
            </Box>
        </Container>
    );
}