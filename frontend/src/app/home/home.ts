import { Component } from "@angular/core";
import { BooksOverview } from "../books-overview/books-overview";

@Component({
  selector: "app-home",
  imports: [BooksOverview],
  templateUrl: "./home.html",
  styleUrls: ["./home.css"],
})
export class Home {}
