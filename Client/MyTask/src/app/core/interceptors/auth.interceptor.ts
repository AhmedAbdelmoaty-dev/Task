import { HttpInterceptorFn } from "@angular/common/http"

export const authInterceptor: HttpInterceptorFn = (req, next) => {
    const clonedRrequst = req.clone({
        setHeaders: {
            'x-auth-token': `mytoken`
        }
    })
   return next(clonedRrequst)
}
