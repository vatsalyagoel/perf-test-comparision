package controllers

import (
	"encoding/json"
	"golang-weather/database"
	"golang-weather/entities"
	"math/rand"
	"net/http"
	"time"

	"github.com/gorilla/mux"
)

var summaries = []string {  "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" }

func GetWeatherForecast(w http.ResponseWriter, r *http.Request) {
  city := mux.Vars(r)["city"]
  var resp [5]entities.WeatherForecast
  for i := 0; i < 5; i++ {
    var tempC = rand.Intn(75)-20
    resp[i] = entities.WeatherForecast{
      Date: time.Now().AddDate(0 ,0, i+1).Format(time.DateOnly),
      TemperatureC: tempC,
      TemperatureF: int(32 + (float32(tempC)/float32(0.5556))),
      City: city,
      Summary: summaries[rand.Intn(len(summaries))],
    }
  }
  w.Header().Set("Content-Type", "application/json")
  w.WriteHeader(http.StatusOK)
  _ = json.NewEncoder(w).Encode(resp)
}


func GetWeatherForecastFromDb(w http.ResponseWriter, r *http.Request) {
  city := mux.Vars(r)["city"]
  var resp []entities.WeatherForecast

  database.Instance.Table("WeatherForecast").Where("city = ?", city).Find(&resp)
  for i, forecast := range resp {
    resp[i].TemperatureF = int(32 + (float32(forecast.TemperatureC)/float32(0.5556)))
  }
  w.Header().Set("Content-Type", "application/json")
  w.WriteHeader(http.StatusOK)
  _ = json.NewEncoder(w).Encode(resp)
}
