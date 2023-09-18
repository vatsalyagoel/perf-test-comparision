package main

import (
	"fmt"
	"golang-weather/controllers"
	"golang-weather/database"
	"log"
	"net/http"

	"github.com/gorilla/mux"
)

func RegisterProductRoutes(router *mux.Router) {
	router.HandleFunc("/api/WeatherForecast/{city}", controllers.GetWeatherForecast).Methods("GET")
	router.HandleFunc("/api/WeatherForecast/db/{city}", controllers.GetWeatherForecastFromDb).Methods("GET")
}

func main() {
	// Load Configurations from config.json using Viper
	LoadAppConfig()
	// Initialize Database
	database.Connect(AppConfig.ConnectionString)

	// Initialize the router
	router := mux.NewRouter().StrictSlash(true)
	// Register Routes
	RegisterProductRoutes(router)
	// Start the server
	log.Printf("Starting Server on port %s\n", AppConfig.Port)
	log.Fatal(http.ListenAndServe(fmt.Sprintf(":%v", AppConfig.Port), router))
}
