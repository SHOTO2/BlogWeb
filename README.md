# Comprehensive API System

This API system is designed for managing posts, adding comments to each post, and handling login functionality. The system uses advanced design patterns like dependency injection and the repository pattern for scalable architecture. JWT (JSON Web Tokens) are used to ensure security and continuous user verification. Authorization mechanisms are in place to control access, ensuring that only authorized users can delete or update posts, while others are allowed to create posts.

Entity Framework is used for querying the database, with a database-first approach to ensure proper organization and maintain database integrity.

## System Overview

### API Features:

- **User Management**
- **Post Management**
- **Comment Management**

### Technologies Used:

- **JWT** for authentication and authorization
- **Dependency Injection** for scalable and maintainable architecture
- **Repository Pattern** for data access and abstraction
- **Entity Framework** for data querying (database-first approach)
  
---

## User Management

### Login
- User can log in to the system securely.
- JWT tokens are used to maintain session and verify user identity.

---

## Post Management

### Add Post
- Only **users** are allowed to create posts.
  
### Update Post
- Only **Admin** are allowed to update existing posts.

### Fetch All Posts of the User
- Allows fetching of all posts created by the logged-in user.

### Fetch a Post by Post ID
- A user can fetch any post using its unique post ID.

---

## Comment Management

### Add Comment
- Users can add comments to a specific post.

### Delete Comment
- Users can delete their own comments on posts.
- Admin users may have elevated permissions to delete comments from other users, depending on the design.

---

## Security and Authorization

- **JWT Authentication**: Ensures secure login and session management.
- **Authorization**: 
  - Only Admins with the correct permissions can update or delete posts.
  - Regular users can only create new posts and add comments.
  - Admin have full control over post creation, updates, and deletions.

---

## Design Patterns

- **Repository Pattern**: This pattern is used for managing the data layer, helping to decouple the business logic from the data access code.
- **Dependency Injection**: Promotes loose coupling between components, making the system more maintainable and testable.
****
