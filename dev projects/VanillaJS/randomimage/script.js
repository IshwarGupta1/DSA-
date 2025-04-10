const userImg = document.getElementById("user-img");
const userName = document.getElementById("user-name");
const userEmail = document.getElementById("user-email");
const fetchUserBtn = document.getElementById("fetchUserBtn");

// Function to fetch random user
async function fetchRandomUser() {
    try {
        const response = await fetch("https://randomuser.me/api/"); // Fetch user data
        const data = await response.json(); // Convert response to JSON
        const user = data.results[0]; // Extract user info
        
        // Update UI with user details
        userImg.src = user.picture.large;
        userName.textContent = `${user.name.first} ${user.name.last}`;
        userEmail.textContent = user.email;
    } catch (error) {
        console.error("Error fetching user:", error);
    }
}

// Add event listener to button
fetchUserBtn.addEventListener("click", fetchRandomUser);

// Load a user on page load
fetchRandomUser();
