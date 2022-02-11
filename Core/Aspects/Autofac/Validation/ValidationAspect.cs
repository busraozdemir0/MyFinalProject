using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {//Aspect: metodun başında veya sonunda hata verdiğinde çalışacak yapıdır
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensive coding
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {//IValidator atanamazsa hata gönderecek(tipin sadece IValidator olması için)
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }

        //doğrulama metodun başında yapıldığından dolayı sadece OnBefore metodunu yazmamız yeterlidir
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//çalışma anında new'lemek için
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
