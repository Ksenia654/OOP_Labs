## DocManager - Lab 2

To accomplish this task you will need to develop a **console-based document editor** that allows users to create, edit, format, and save documents while utilizing key **Object-Oriented Programming (OOP) design patterns**. The implementation must include **behavioral, structural, and creational patterns**, ensuring a well-structured and maintainable codebase.

1. **Document Management**
    - Create, open, edit, and delete documents
    - Support different document types (PlainText, Markdown, RichText)
    - Save/load documents in various formats (TXT, JSON, XML)
2. **Text Editing & Formatting**
    - Insert, delete, and modify text
    - Apply formatting (bold, italic,) using decorators
    - Support copy, cut, and paste operations
3. **Undo/Redo System**
    - Ability to undo/redo text modifications
4. **Storage Options**
    - Store documents in **local files, the cloud**
5. **User Roles & Permissions**
    - Roles: **Viewer (read-only), Editor (edit access), Admin (manage users & permissions)**
    - Notify users of document changes
6. **Settings & Customization**
    - Manage global editor settings (theme, font size)

Acceptance criteria:

1. GitHub repo and MR is required.
2. Read.me file is required with the following information:
    1. Description of ur project.
    2. **YOUR NAME AND GROUP NUMBER**
    3. Link, photo or attachment of your system’s class **UML** diagram (it could be clarified later, the main purpose of it to provide an overview how your system’s architecture).
3. Working application resistant to any user input is required.
4. A set of test-cases is required.
5. Convenient command interface is required.
6. Theoretical knowledge of basic OOP Patterns.s

### P.S. User stories

- **Basic Document Management**
    - 📝 **As a user, I want to create a new document so that I can start writing content.**
    - 📂 **As a user, I want to open an existing document so that I can continue working on it.**
    - 💾 **As a user, I want to save my document in different formats (TXT, JSON, XML) so that I can choose the best option for my needs.** *(Adapter Pattern)*
    - 🗑 **As a user, I want to delete a document so that I can remove unnecessary files.**
- **Text Editing & Formatting**
    - 🔤 **As a user, I want to type and edit text in my document so that I can modify its content.**
    - 🔠 **As a user, I want to apply formatting (bold, italic, underline) so that my text is visually styled.** *(Decorator Pattern)*
    - ✂️ **As a user, I want to cut, copy, and paste text so that I can efficiently edit my document.**
    - 🔍 **As a user, I want to search for words in the document so that I can quickly find specific content.**
- **Undo & Redo System** *(Command Pattern)*
    - ↩ **As a user, I want to undo my last action so that I can revert mistakes.**
    - ↪ **As a user, I want to redo an undone action so that I can restore changes.**
- **User Roles & Permissions** *(Strategy Pattern / Observer Pattern)*
    - 👁 **As a viewer, I want to open a document in read-only mode so that I can read it without making changes.**
    - ✏️ **As an editor, I want to modify the document so that I can update the content.**
    - 🔐 **As an admin, I want to manage user permissions so that I can control who can edit or view a document.** *(Observer Pattern for role changes)*
- **Multi-Format & Storage Options** *(Factory / Strategy Patterns)*
    - ☁ **As a user, I want to save my document in different locations (local file, database, cloud) so that I have flexible storage options.** *(Strategy Pattern)*
    - 🔄 **As a user, I want to convert my document to different formats (Markdown, JSON, XML) so that I can use it in other applications.** *(Adapter Pattern)*
- **Notifications & Collaboration** *(Observer Pattern)*
    - 📢 **As a user, I want to receive notifications when someone edits the document so that I can stay updated.** *(Observer Pattern)*
- **Application Settings & History** *(Singleton Pattern)*
    - ⚙ **As a user, I want to change editor settings (font size, theme) so that I can personalize my experience.** *(Singleton Pattern for settings management)*
    - 📜 **As a user, I want to view my document history so that I can track changes over time.**
