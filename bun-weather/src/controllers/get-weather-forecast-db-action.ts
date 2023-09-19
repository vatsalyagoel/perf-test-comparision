import { Request, Response } from "express";
import { WeatherForecast } from "../entities/weather-forecast";
import { AppDataSource } from "../data-source";

export async function getWeatherForecastDbAction(request: Request, reponse: Response) {
    const city = request.params.city;
    const forecasts = await AppDataSource.getRepository(WeatherForecast).find({ where: { city: city } });
    reponse.send(forecasts);
}