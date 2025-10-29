import React from "react";
import {render, screen} from "@testing-library/react"
import { describe, it, expect } from "vitest";
import Home from "../../pages/home/home"

describe("Blog component tests", () => {
    it("should contain a description",() => {
        render(<Home />)
        expect(screen.getByText("Blogs")).toBeInTheDocument();
    })
});