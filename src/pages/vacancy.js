import { Typography, Container } from "@material-ui/core";
import Box from "@mui/material/Box";
import CardHeader from "@mui/material/CardHeader";
import CardContent from "@mui/material/CardContent";
import Card from "@mui/material/Card";
import { useEffect, useState } from "react";
import { useNavigate } from 'react-router-dom';
import Link from "@mui/material/Link";

export default function Vacancy() {
    const [vacancies, setVacancies] = useState([]);
    const navigate = useNavigate();

    function handleClick() {
        navigate("/createVacancy");
    }

    useEffect(() => {
         fetchData();
    }, [vacancies])

    const fetchData = async () => {
        try {
           const response =  await fetch('https://localhost:7031/api/vacancies');
           const jsonData = await response.json();
            setVacancies(jsonData);
    
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <Container component="main" maxWidth="lg">
            <Typography component="h1" variant="h5">
                Vacancies | <Link onClick={handleClick}>Create Vacancies</Link>
            </Typography>
            {vacancies.map((vacancy) => (
                <Box sx={{ mt: 1 }}>
                    <Card sx={{ maxWidth: 1300, mx: 'auto' }}>
                        <CardHeader
                            title={vacancy.companyName}
                            subheader={"Closing date: " + vacancy.closingDate}
                        />
                        <CardContent>
                            <Typography variant="body2" color="text.secondary">
                                {vacancy.description}
                            </Typography>
                        </CardContent>
                    </Card>
                </Box>
            ))}
        </Container>
    );

}