package org.example.models;

public class Customer {
    private String name;
    private String emailId;
    private String contactNum;
    private String licenseNumber;

    public Customer(String name, String emailId, String contactNum, String licenseNumber) {
        this.name = name;
        this.emailId = emailId;
        this.contactNum = contactNum;
        this.licenseNumber = licenseNumber;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getEmailId() {
        return emailId;
    }

    public void setEmailId(String emailId) {
        this.emailId = emailId;
    }

    public String getContactNum() {
        return contactNum;
    }

    public void setContactNum(String contactNum) {
        this.contactNum = contactNum;
    }

    public String getLicenseNumber() {
        return licenseNumber;
    }

    public void setLicenseNumber(String licenseNumber) {
        this.licenseNumber = licenseNumber;
    }
}
