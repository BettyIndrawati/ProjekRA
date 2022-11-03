namespace RAS.Bootcamp.RumahAqiqah.Data;

public class RegisterRequest
{
    public int? RoleId {get; set;}
    public string RoleCode {get; set;}
    public string RoleName{get; set;}
    public string? Description{get; set;}
    public string Username{get; set;}
    public string Password{get; set;}
    public string Name{get; set;}
    public string Email{get; set;}
    public string PhoneNumber{get; set;}
    public string ReferalCode{get; set;}
    public string? PoB {get; set;}
    public DateTime? DoB {get; set;}
    public string? Address {get; set;}
    public string? IdentityNumber {get; set;}
    public string? RT {get; set;}
    public string? RW {get; set;}
    public string? District {get; set;}
    public string? City {get; set;}
}