import "reflect-metadata";
import { Request, Response } from "express";
import express from "express";
import * as bodyParser from "body-parser";
import { AppDataSource } from "./data-source";
import { Routes } from "./routes";


AppDataSource.initialize().then(async () => {
    const app = express();
    app.use(bodyParser.json());

    for (const route of Routes) {
        app[route.method](route.path, (request: Request, response: Response, next: Function) => {
            route.action(request, response)
                .then(() => next)
                .catch((err: Error) => next(err));
        });
    }
    console.log(Bun.env.DB_PATH)

    const port = Bun.env.PORT ?? 3000;
    app.listen(port, () => {
        console.log(`Server started on port ${port}!`);
    });
}).catch((err: Error) => console.error(err));