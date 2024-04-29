type ValidationResult = string | boolean;
type ValidationRule =
  | ValidationResult
  | PromiseLike<ValidationResult>
  | ((value: any) => ValidationResult)
  | ((value: any) => PromiseLike<ValidationResult>);
const required: ValidationRule = (value) => !!value || 'This field is required.';
const fileRequired: ValidationRule = (value) => value || value.length || 'This field is required.';

export default { required, fileRequired };
