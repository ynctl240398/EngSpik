import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { AuthenComponent } from "./authen.component";

const routes: Routes = [
  {
    path: "",
    component: AuthenComponent,
    children: [
      {
        path: "",
        redirectTo: "login",
        pathMatch: "full",
      },
      {
        path: "login",
        loadChildren: () =>
          import("./login/login.module").then((m) => m.LoginModule),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AuthenRoutingModule {}
