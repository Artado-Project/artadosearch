import express from 'express';
import cookieParser from 'cookie-parser';
import mongoose from 'mongoose';
import cors from 'cors';
import dotenv from 'dotenv';

dotenv.config();

//Connect to the MongoDB database
const constr = "mongodb://localhost";

async function ConnectToDB(constr:string) {
    await mongoose.connect(constr);
    console.log("Connected to database succesfully!");
}

try{
    await ConnectToDB(constr);
}
catch(e){
    console.log("Ups! Something went wrong while trying to connect to the database. Error:", e);
}

const PORT = 3000;

const app = express();
app.use(express.json());
app.use(express.urlencoded({extended: false}));
app.use(cors());
app.use(cookieParser());

function API(){
    app.get("/api", (req, res) => {
        res.status(200).send("works!");
        return(<h1>WORKS</h1>);
    });
    
    app.listen(PORT, () => {
        console.log("Artado is listening on port ${PORT}");
        return(<h1>WORKS</h1>);
    });

    return(<h1>not workin</h1>);
}

export default API;

