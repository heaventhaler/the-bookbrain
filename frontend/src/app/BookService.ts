import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Book } from "./book";

@Injectable({
  providedIn: "root",
})
export class BookService {
  private apiUrl = `${apiUrl}/books`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Book[]> {
    return this.http.get<Book[]>(this.apiUrl);
  }
}

export const apiUrl = "http://localhost:5105/api";
