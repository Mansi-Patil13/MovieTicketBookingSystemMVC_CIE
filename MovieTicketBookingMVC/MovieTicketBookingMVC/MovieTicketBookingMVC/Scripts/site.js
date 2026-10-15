document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll("form").forEach(function (form) {
        form.addEventListener("submit", function () {
            var button = form.querySelector('button[type="submit"]');
            if (button && button.dataset.busy === "true") return;
            if (button) {
                button.dataset.busy = "true";
                button.dataset.originalText = button.textContent;
                button.textContent = "Please wait...";
                window.setTimeout(function () {
                    button.dataset.busy = "false";
                    button.textContent = button.dataset.originalText || "Submit";
                }, 4000);
            }
        });
    });
});
