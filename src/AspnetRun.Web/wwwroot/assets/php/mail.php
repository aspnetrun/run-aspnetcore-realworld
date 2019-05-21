<?php

    // Only process POST reqeusts.
    if ($_SERVER["REQUEST_METHOD"] == "POST") {
        // Get the form fields and remove whitespace.
        $first_name = strip_tags(trim($_POST["first_name"]));
				$first_name = str_replace(array("\r","\n"),array(" "," "),$first_name);
        $last_name = trim($_POST["last_name"]);
        $email = filter_var(trim($_POST["email_address"]), FILTER_SANITIZE_EMAIL);
        $phone = trim($_POST["phone_number"]);
        $message = trim($_POST["message"]);

        // Check that data was sent to the mailer.
        if ( empty($first_name) OR empty($last_name) OR empty($phone) OR empty($message) OR !filter_var($email, FILTER_VALIDATE_EMAIL)) {
            // Set a 400 (bad request) response code and exit.
            http_response_code(400);
            echo "Please complete the form and try again.";
            exit;
        }

        // Set the recipient email address.
        // FIXME: Update this to your desired email address.
        $recipient = "admin@devitems.com";

        // Set the email subject.
        $subject = "New contact from $first_name";

        // Build the email content.
        $email_content = "Name: $first_name\n";
        $email_content = "Name: $last_name\n";
        $email_content .= "Email: $email\n\n";
        $email_content .= "Email: $phone\n\n";
        $email_content .= "Message:\n$message\n";

        // Build the email headers.
        $email_headers = "From: $first_name <$email>";

        // Send the email.
        if (mail($recipient, $subject, $email_content, $email_headers)) {
            // Set a 200 (okay) response code.
            http_response_code(200);
            echo "Thank You! Your message has been sent.";
        } else {
            // Set a 500 (internal server error) response code.
            http_response_code(500);
            echo "Oops! Something went wrong and we couldn't send your message.";
        }

    } else {
        // Not a POST request, set a 403 (forbidden) response code.
        http_response_code(403);
        echo "There was a problem with your submission, please try again.";
    }

?>
