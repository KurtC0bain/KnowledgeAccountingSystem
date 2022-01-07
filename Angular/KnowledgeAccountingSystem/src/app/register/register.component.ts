import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';
import { AdministrationService } from '../administration.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  form: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private router: Router,
     private admin:AdministrationService
  ) {
  }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      FirstName: '',
      LastName: '',
      Email: '',
      Password: '',
      ConfirmPassword: '',
      Role: ''
    });
  }

  submit(): void {
    this.http.post('https://localhost:44392/api/Administration/SignUp', this.form.getRawValue())
      .subscribe(() => this.router.navigate(['/login']));
  }
}