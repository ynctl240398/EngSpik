import { en_US, NgZorroAntdModule, NZ_I18N } from "ng-zorro-antd";
import { ModuleWithProviders, NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";

@NgModule({
  declarations: [],
  imports: [CommonModule, NgZorroAntdModule, FormsModule, HttpClientModule],
  exports: [NgZorroAntdModule],
})
export class SharedModule {
  static forRoot(): ModuleWithProviders<SharedModule> {
    return {
      ngModule: SharedModule,
      providers: [{ provide: NZ_I18N, useValue: en_US }],
    };
  }
}
