import { Component } from "@angular/core";
import { Home } from "./features/home/home";

@Component({
  selector: "app-root",
  imports: [Home],
  templateUrl: "./app.html",
  styleUrls: ["./app.css"],
})
export class App {
  title = "default";
}
