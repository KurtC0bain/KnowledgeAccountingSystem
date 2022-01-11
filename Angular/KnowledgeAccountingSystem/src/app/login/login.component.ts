import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import { AdministrationService } from '../administration.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  form!: FormGroup;
  currentUserName: string = "";

  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private admin: AdministrationService
  ) {
  }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      Email: '',
      Password: ''
    });
  }

  submit(): void {
    this.admin.SignIn(this.form.getRawValue())
  }
}