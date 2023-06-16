import { Typography, Container } from "@material-ui/core";
import Box from "@mui/material/Box";
import CardHeader from "@mui/material/CardHeader";
import CardContent from "@mui/material/CardContent";
import Card from "@mui/material/Card";
import { useEffect, useState } from "react";
import { useNavigate } from 'react-router-dom';
import Link from "@mui/material/Link";

export default function Freelancer() {
    const [freelancers, setFreelancer] = useState([]);
    const navigate = useNavigate();

    function handleClick() {
        navigate("/createFreelancer");
    }

    useEffect(() => {
        fetchData();
    }, [freelancers])

    const fetchData = async () => {
        try {
            const response = await fetch('https://localhost:7031/api/Freelancer');
            const jsonData = await response.json();
            setFreelancer(jsonData)
        } catch (error) {
            console.error(error);
        }
    };

    return (<Container component="main" maxWidth="lg">
        <Typography component="h1" variant="h5">
            Freelancer | <Link onClick={handleClick}>Create Freelancer</Link>
        </Typography>
        {freelancers.map((freelancer) => (
            <Box
                sx={{ mt: 1 }}
            >
                <Card sx={{ maxWidth: 1300, mx: 'auto' }}>
                    <CardHeader
                        title={freelancer.jobTitle}
                        subheader={freelancer.location}
                    />
                    <CardContent>
                        <Typography variant="body2" color="text.secondary">
                            {freelancer.description}
                        </Typography>
                    </CardContent>
                </Card>
            </Box>
        ))}
    </Container>
    );
}