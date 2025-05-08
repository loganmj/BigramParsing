# BigramParsing

## 📘 Project Overview

**BigramParsing** is a WPF desktop application written in C# that parses a block of text into bigrams—pairs of consecutive words—and displays a histogram of their frequencies.

---

## ✨ Features

- Clean WPF user interface for input and output
- Parses input text into bigrams (two-word combinations)
- Displays frequency counts of each bigram
- Includes unit tests using MSTest

---

## 🛠️ Technologies Used

- **Language:** C#
- **Framework:** .NET (WPF)
- **Testing:** MSTest

---

## 🚀 Getting Started

### Prerequisites

- Visual Studio 2019 or later
- .NET Desktop Development workload

### Running the Application

1. Clone the repository:
   ```bash
   git clone https://github.com/loganmj/BigramParsing.git
   cd BigramParsing
   ```

2. Open the solution file (`BigramParsing.sln`) in Visual Studio.

3. Build and run the project (F5 or Ctrl+F5).

---

## 🧪 Running Tests

To run the unit tests:

1. Open the **Test Explorer** in Visual Studio.
2. Click **Run All Tests**.

---

## 💡 Example

**Input:**
```
The quick brown fox jumps over the quick brown dog.
```

**Output:**
```
(the, quick): 2
(quick, brown): 2
(brown, fox): 1
(fox, jumps): 1
(jumps, over): 1
(over, the): 1
(the, brown): 1
(brown, dog): 1
