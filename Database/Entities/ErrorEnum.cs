namespace PFM_project.Database.Entities
{
    public enum ErrorEnum
    {
        min_length,
        max_length, 
        required,
        out_of_range,
        invalid_format,
        unknown_enum,
        not_on_list,
        check_digit_invalid,
        combination_required,
        read_only
        
    }
}