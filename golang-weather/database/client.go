package database

import (
	"log"

	"gorm.io/driver/sqlite"
	"gorm.io/gorm"
)

var Instance *gorm.DB
var err error

func Connect(connectionString string) {
  Instance, err = gorm.Open(sqlite.Open(connectionString), &gorm.Config{})
  if err != nil {
    log.Fatal(err)
    panic("Cannot connect to DB")
  }
  log.Println("Connected to Database...")
}
