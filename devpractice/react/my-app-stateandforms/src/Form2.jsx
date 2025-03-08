import { useState } from "react";

function Form2() {
  const [formData, setFormData] = useState({
    userName: "",
    email: "",
    gender: "", // Radio button
    country: "", // Dropdown
    agreeToTerms: false // Checkbox
  });

  const handleChange = (event) => {
    const { name, value, type, checked } = event.target;
    
    setFormData({
      ...formData,
      [name]: type === "checkbox" ? checked : value // Checkbox uses `checked`
    });
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    alert(`Details Submitted: ${JSON.stringify(formData, null, 2)}`);
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        {/* Text Inputs */}
        <input
          type="text"
          name="userName"
          value={formData.userName}
          onChange={handleChange}
          placeholder="Enter Username"
        />

        <input
          type="text"
          name="email"
          value={formData.email}
          onChange={handleChange}
          placeholder="Enter Email"
        />

        {/* Radio Buttons */}
        <div>
          <label>Gender: </label>
          <input
            type="radio"
            name="gender"
            value="male"
            checked={formData.gender === "male"}
            onChange={handleChange}
          />
          Male
          <input
            type="radio"
            name="gender"
            value="female"
            checked={formData.gender === "female"}
            onChange={handleChange}
          />
          Female
        </div>

        {/* Dropdown (Select Box) */}
        <div>
          <label>Country: </label>
          <select name="country" value={formData.country} onChange={handleChange}>
            <option value="">Select Country</option>
            <option value="india">India</option>
            <option value="usa">USA</option>
            <option value="uk">UK</option>
          </select>
        </div>

        {/* Checkbox */}
        <div>
          <input
            type="checkbox"
            name="agreeToTerms"
            checked={formData.agreeToTerms}
            onChange={handleChange}
          />
          <label> I agree to the terms and conditions</label>
        </div>

        {/* Submit Button */}
        <button type="submit">Submit</button>
      </form>
    </div>
  );
}

export default Form2;
