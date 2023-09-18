package entities

type WeatherForecast struct {
  Date string `json:"date" gorm:"column:date"`
  TemperatureC int `json:"temperaturec" gorm:"column:temperaturec"`
  TemperatureF int `json:"temperaturef"`
  City string `json:"city" gorm:"column:city"`
  Summary string `json:"summary" gorm:"column:summary"`
}

