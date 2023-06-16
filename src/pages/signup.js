import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import Link from "@mui/material/Link";
import Paper from "@mui/material/Paper";
import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import Typography from "@mui/material/Typography";
import { Container } from "@mui/material";
import { useNavigate } from 'react-router-dom';
import { useState } from "react";

export default function Signup() {
    const navigate = useNavigate();
    const [signResponse, setSignResponse] = useState();
    const handleSubmit = (event) => {
        event.preventDefault();
        const data = new FormData(event.currentTarget);
        let infor = {
            emailAddress: data.get("emailAddress"),
            password: data.get("password"),
            firstName: data.get("firstname"),
            lastName: data.get("lastname"),
            gender: data.get("gender"),
        }
        

        fetch('https://localhost:7031/api/user/CreateUser', {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(infor)
        }).then(response => setSignResponse(response))

        navigate("/vacancy");       
    };

    function handleClick() {
        navigate("/login");
    }

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
                                Sign up
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
                                    name="firstname"
                                    label="Firstname"
                                    type="text"
                                    id="firstname"
                                />
                                <TextField
                                    margin="normal"
                                    required
                                    fullWidth
                                    name="lastname"
                                    label="Lastname"
                                    type="text"
                                    id="lastname"
                                />
                                <TextField
                                    margin="normal"
                                    required
                                    fullWidth
                                    name="gender"
                                    label="Gender"
                                    type="text"
                                    id="gender"
                                />
                                <TextField
                                    margin="normal"
                                    required
                                    fullWidth
                                    id="emailAddress"
                                    label="Email Address"
                                    name="emailAddress"
                                    autoComplete="email"
                                    autoFocus
                                />
                                <TextField
                                    margin="normal"
                                    required
                                    fullWidth
                                    name="password"
                                    label="Password"
                                    type="password"
                                    id="password"
                                    autoComplete="current-password"
                                />
                                <TextField
                                    margin="normal"
                                    required
                                    fullWidth
                                    name="confirm password"
                                    label="Confirm Password"
                                    type="password"
                                    id="password"
                                    autoComplete="current-password"
                                />
                                <Button
                                    type="submit"
                                    fullWidth
                                    variant="contained"
                                    sx={{ mt: 3, mb: 2 }}
                                >
                                    Sign Up
                                </Button>
                                <Grid container>
                                    <Grid item>
                                        <Link href="#" variant="body2" onClick={handleClick}>
                                            {"Already have an account? Sign In"}
                                        </Link>
                                    </Grid>
                                </Grid>
                                <Grid container>
                                    <Grid sx={{ mt: 3, mb: 2 }} color={'red'}>
                                        {signResponse}
                                    </Grid>
                                </Grid>
                            </Box>
                        </Box>
                    </Grid>
                </Grid>
            </Box>
        </Container>
    );
}