import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { RouterUrl } from "./shared/core/constant";

const routes: Routes = [
  {
    path: "",
    redirectTo: RouterUrl.HOME,
    pathMatch: "full",
  },
  {
    path: RouterUrl.HOME,
    loadChildren: () =>
      import("./modules/home/home.module").then((m) => m.HomeModule),
  },
  {
    path: RouterUrl.AUTHEN,
    loadChildren: () =>
      import("./modules/authen/authen.module").then((m) => m.AuthenModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
