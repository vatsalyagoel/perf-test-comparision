import { Request, Response } from "express";
import { WeatherForecast } from "../entities/weather-forecast";

const summaries: string[] = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

export function getWeatherForecastAction(request: Request, reponse: Response) {
    const city = request.params.city;
    const forecasts = new Array<WeatherForecast>();
    for (let i = 0; i < 5; i++) {
        const tempC = getRandomIntRange(-20, 55);
        const tempF = 32 + (tempC / 0.5556);
        const summary = summaries[getRandomInt(summaries.length - 1)];
        const forecast = new WeatherForecast();
        forecast.date = addDays(new Date(), i + 1);
        forecast.temperatureC = tempC;
        forecast.temperatureF = Math.round(tempF);
        forecast.summary = summary;
        forecast.city = city;
        forecasts.push(forecast);
    }
    reponse.send(forecasts);
}

function addDays(date: Date, days: number): Date {
    date.setDate(date.getDate() + days);
    return date;
}

function getRandomIntRange(min: number, max: number) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min + 1) + min); // The maximum is inclusive and the minimum is inclusive
}

function getRandomInt(max: number) {
    return Math.floor(Math.random() * max);
}
