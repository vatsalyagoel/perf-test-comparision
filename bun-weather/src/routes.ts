import { getWeatherForecastAction } from "./controllers/get-weather-forecast-action";
import { getWeatherForecastDbAction } from "./controllers/get-weather-forecast-db-action";

/**
 * All application routes.
 */

type Route = {
    path: string;
    method: "get" | "post" | "put" | "delete" | "patch";
    action: Function;
}

export const Routes: Route[] = [
    {
        path: "/api/WetherForecast/:city",
        method: "get",
        action: getWeatherForecastAction
    },
    {
        path: "/api/WetherForecast/db/:city",
        method: "get",
        action: getWeatherForecastDbAction
    },
];