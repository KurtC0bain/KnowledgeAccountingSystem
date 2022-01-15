import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { AdministrationService } from '../administration.service';
import { ResetPassword } from '../models/ResetPassword';
import { first } from 'rxjs';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {
  public resetPasswordForm: FormGroup;
  public showSuccess: boolean;
  public showError: boolean;
  public errorMessage: string;

  private _token: string;
  private _email: string;

  constructor(private admin: AdministrationService, private _route: ActivatedRoute) { }

  ngOnInit(): void {
    this.resetPasswordForm = new FormGroup({
      password: new FormControl('', [Validators.required]),
      confirmPassword: new FormControl('', [Validators.required])
    });
    

      this._token = this._route.snapshot.queryParams['token'];
      this._email = this._route.snapshot.queryParams['email'];
  }

  resetPassword = (resetPasswordFormValue: ResetPassword) => {
    this.showError = this.showSuccess = false;
    const resetPass = { ... resetPasswordFormValue };
    const resetPassModel: ResetPassword = {
      password: resetPass.password,
      confirmPassword: resetPass.confirmPassword,
      token: this._token,
      email: this._email
    }

    this.admin.ResetPassword(resetPassModel).pipe(first()).subscribe(data => {
      this.showSuccess = true;
    },
    err => {
      this.showError = true;
      this.errorMessage = "Wrong Input";
    }
    )
  }
}