import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { RouterUrl } from "src/app/shared/core/constant";

import { AuthenComponent } from "./authen.component";

const routes: Routes = [
  {
    path: "",
    component: AuthenComponent,
    children: [
      {
        path: "",
        redirectTo: RouterUrl.LOGIN,
        pathMatch: "full",
      },
      {
        path: RouterUrl.LOGIN,
        loadChildren: () =>
          import("./login/login.module").then((m) => m.LoginModule),
      },
      {
        path: RouterUrl.REGISTER,
        loadChildren: () =>
          import("./register/register.module").then((m) => m.RegisterModule),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AuthenRoutingModule {}
