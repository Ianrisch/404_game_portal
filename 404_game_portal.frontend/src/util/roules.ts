type ValidationResult = string | boolean;
type ValidationRule =
  | ValidationResult
  | PromiseLike<ValidationResult>
  | ((value: any) => ValidationResult)
  | ((value: any) => PromiseLike<ValidationResult>);
const rules: ValidationRule[] = [(value) => !!value || 'This field is required.'];

export default rules;
