import "reflect-metadata";
import { DataSource } from "typeorm";
import { WeatherForecast } from "./entities/weather-forecast";

export const AppDataSource = new DataSource({
    type: "sqlite",
    database: process.env.DB_PATH ?? "db.sqlite",
    entities: [WeatherForecast],
    logging: true,
});