import { Column, Entity, PrimaryColumn } from "typeorm"

@Entity("WeatherForecast")
export class WeatherForecast {
  @PrimaryColumn({ name: "id", type: "int" })
  id!: number
  @Column({name: "date", type: "date"})
  date!: Date
  @Column({name: "temperaturec", type: "integer"})
  temperatureC!: number
  temperatureF!: number
  @Column({name:"summary", type: "varchar"}) summary?: string
  @Column({name: "city", type: "varchar"}) city?: string
}
