import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  form!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      Email: '',
      Password: ''
    });
  }

  submit(): void {
    this.http.post('https://localhost:44392/api/Administration/SignIn', this.form.getRawValue(), {
      withCredentials: true,
      responseType: 'text' as 'json'
    }).subscribe(() => this.router.navigate(['/knowledge']));
  }
}